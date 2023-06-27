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
