// Define la interfaz ICommand para los comandos
public interface ICommand
{
    void Execute();
}

// Implementa diferentes comandos concretos
public class LightOnCommand : ICommand
{
    private readonly Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

public class LightOffCommand : ICommand
{
    private readonly Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}

// Define la clase Receiver (Receptor) que realiza las acciones
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("La luz está encendida.");
    }

    public void TurnOff()
    {
        Console.WriteLine("La luz está apagada.");
    }
}

// Implementa la clase Invoker (Invocador) que ejecuta los comandos
public class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }
}

// Cliente
public class Client
{
    public static void Main(string[] args)
    {
        // Crea el receptor (Receiver)
        var light = new Light();

        // Crea los comandos concretos y les pasa el receptor
        var lightOnCommand = new LightOnCommand(light);
        var lightOffCommand = new LightOffCommand(light);

        // Crea el invocador (Invoker) y configura los comandos
        var remoteControl = new RemoteControl();
        remoteControl.SetCommand(lightOnCommand);

        // Presiona el botón del control remoto
        remoteControl.PressButton(); // Enciende la luz

        // Configura un nuevo comando
        remoteControl.SetCommand(lightOffCommand);

        // Presiona el botón del control remoto nuevamente
        remoteControl.PressButton(); // Apaga la luz
    }
}
