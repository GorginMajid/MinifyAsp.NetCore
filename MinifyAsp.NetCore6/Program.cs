using WebMarkupMin.AspNetCore5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Add WebMarkupMin Service
builder.Services.AddWebMarkupMin(opt =>
{
    opt.AllowCompressionInDevelopmentEnvironment = true;
    opt.AllowMinificationInDevelopmentEnvironment =true;
})
    .AddHttpCompression()
    .AddHtmlMinification().
    AddXmlMinification();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Added WebMarkupMin Middlware
app.UseWebMarkupMin();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
