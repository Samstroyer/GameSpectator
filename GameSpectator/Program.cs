using System.Text.Json;
using RestSharp;
using Raylib_cs;

RestClient client = new RestClient("http://2.249.166.70:3000");
RestRequest getPaul = new("Paul/Get", Method.Get);
RestRequest getSamuel = new("Samuel/Get", Method.Get);

RestResponse responseSamuel;
RestResponse responsePaul;

Player paul = new(Color.RED);
Player samuel = new(Color.GREEN);

Setup();
Draw();

void Setup()
{
    Raylib.SetTargetFPS(45);
    Raylib.InitWindow(800, 800, "Gibb Spec");
}

void Draw()
{
    Color c = Color.RED;

    while (!Raylib.WindowShouldClose())
    {
        GetPositions();

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        paul.Render();
        samuel.Render();

        Raylib.EndDrawing();
    }
}

void GetPositions()
{
    responsePaul = client.GetAsync(getPaul).Result;
    paul.p = JsonSerializer.Deserialize<Position>(responsePaul.Content);

    responseSamuel = client.GetAsync(getSamuel).Result;
    samuel.p = JsonSerializer.Deserialize<Position>(responseSamuel.Content);
}