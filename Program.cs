namespace AtivProjLHPet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto WEB - LH Pets versão 1!");

// Habilitando o usestaticfiles para os usuários terem acesso ao index na pasta wwwroot
        app.UseStaticFiles();
        app.MapGet("/index",(HttpContext Contexto)=>{
            Contexto.Response.Redirect("index.html", false);
        });

        Banco dba = new Banco();
        app.MapGet("/listaClientes",(HttpContext Contexto)=>{
            Contexto.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
