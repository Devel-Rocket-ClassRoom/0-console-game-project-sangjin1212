using System;
using Framework.Engine;

public class Game : GameApp
{
    private readonly SceneManager<Scene> _scenes = new SceneManager<Scene>();

    public Game() : base(60, 30)
    { 
    
    }
    public Game(int width, int height) : base(width, height)
    {
    }

    protected override void Draw()
    {
        _scenes.CurrentScene.Draw(Buffer);
    }

    protected override void Initialize()
    {
        ChangeToTitle();
    }

    protected override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.Escape))
        {
            Quit();
            return;
        }
        _scenes.CurrentScene?.Update(deltaTime);

    }
    public void ChangeToTitle()
    {
        var title = new TitleScene();
        _scenes.ChangeScene(title);
        title.StartRequested += ChangeToPlay;
    }
    public void ChangeToPlay()
    {
        var play = new PlayScene();
        play.TitleRequested += ChangeToTitle;
        _scenes.ChangeScene(play);
    }
}

