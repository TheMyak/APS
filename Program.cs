using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Kestrel para escuchar en puertos HTTP y HTTPS específicos
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Puerto HTTP
    options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // Puerto HTTPS
});

// Configurar DbContext para usar la conexión a la base de datos en Azure
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LibraryDatabase"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3, // Número de reintentos
                maxRetryDelay: TimeSpan.FromSeconds(10), // Tiempo de espera entre reintentos
                errorNumbersToAdd: null); // Opcional, errores específicos
        }));


// Agregar servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Configurar la canalización de solicitud HTTP.
app.UseAuthorization();

app.MapControllers();

app.Run();