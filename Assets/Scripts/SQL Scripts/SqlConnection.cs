using MySqlConnector;
using TMPro;
using UnityEngine;

public class DatabaseTest : MonoBehaviour
{
    private string connectionString = "Server=localhost;Port=3306;Database=teste;User ID=root;Password=12345";

    [SerializeField] private TMP_InputField nomeIF, dataNascimentoIF, numeroAlunoIF;
    [SerializeField] private TMP_Dropdown dropdownGenero;
    private string nome, dataNascimento, numeroAluno, genero;

    void Start()
    {
        TestConnection();
    }

    public async void TestConnection()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync(); // Establishes the connection asynchronously
                Debug.Log("Connection to the database was successful!");
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error connecting to the database: {ex.Message}");
        }
    }

    public async void AddAluno()
    {
        nome = nomeIF.text;
        dataNascimento = dataNascimentoIF.text;
        numeroAluno = numeroAlunoIF.text;
        genero = dropdownGenero.options[dropdownGenero.value].text;

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync(); // Establishes the connection asynchronously

                string query = "Insert into aluno (nome, dataNascimento, numAluno, genero) values (@nome, @dataNascimento, @numAluno, @genero)";

                using (MySqlCommand command = new MySqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@nome",nome);
                    command.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                    command.Parameters.AddWithValue("@numAluno", numeroAluno);
                    command.Parameters.AddWithValue("@genero", genero);

                    int rowsAffted = command.ExecuteNonQuery();
                    Debug.Log("Data Inserted succesfully");

                    nomeIF.text = "";
                    dataNascimentoIF.text = "";
                    numeroAlunoIF.text = "";
                    dropdownGenero.value = 0;

                }
            }

        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error adding to the database: {ex.Message}");
        }

    }

    public async void SearchAluno()
    {
        nome = nomeIF.text;
        dataNascimento = dataNascimentoIF.text;
        numeroAluno = numeroAlunoIF.text;
        genero = dropdownGenero.options[dropdownGenero.value].text;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "Select nome,dataNascimento, numAluno,genero from aluno where nome= @nome";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nomeIF.text = reader.GetString(0);
                            dataNascimentoIF.text=reader.GetString(1);
                            numeroAlunoIF.text = reader.GetString(2);
                            if(reader.GetString(3) == "Masculino")
                            {
                                dropdownGenero.value = 0;
                            }
                            else if(reader.GetString(3) == "Feminino")
                            {
                                dropdownGenero.value = 1;
                            }
                            else
                            {
                                dropdownGenero.value = 2;
                            }

                            Debug.Log("Sucesso");
                        }
                        else
                        {
                            Debug.Log("No Data Found");
                        }
                        reader.Close();
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error adding to the database: {ex.Message}");
        }
    }

    public async void RemoveAluno()
    {
        nome = nomeIF.text;
        dataNascimento = dataNascimentoIF.text;
        numeroAluno = numeroAlunoIF.text;
        genero = dropdownGenero.options[dropdownGenero.value].text;

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync(); // Establishes the connection asynchronously

                string query = "Delete from aluno where nome= @nome";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);

                    int rowsAffected = command.ExecuteNonQuery();
                    Debug.Log("Sucesso");

                    nomeIF.text = "";
                    dataNascimentoIF.text = "";
                    numeroAlunoIF.text = "";
                    dropdownGenero.value = 0;
                }
            }

        }
        catch (MySqlException ex)
        {
            Debug.LogError($"Error adding to the database: {ex.Message}");
        }

    }
}