namespace MessagingCore;

public static class QueueHelper
{
    public static string GetQueueName(string queueName)
    {
        return $"queue:{queueName}";
    }
}