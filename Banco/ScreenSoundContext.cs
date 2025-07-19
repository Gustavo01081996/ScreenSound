using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;
internal class ScreenSoundContext:DbContext
{
    /* Isso indica para o Entity que você quer trabalhar com uma tabela no banco de dados chamada Artistas
     e que no projeto é um objeto chamado Artista.
    Ou seja, aqui você está fazendo o mapeamento do banco de dados com o objeto */
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    // Essa string fica localizada em "Propriedades" do banco de dados -> "Cadeia de Conexao"
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial " +
        "Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server " +
        "Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


    // método sobrescrito responsável por realizar a conexão com o banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }
}
