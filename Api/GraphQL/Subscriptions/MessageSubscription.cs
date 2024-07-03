namespace EventOrchestrationService.Api.GraphQL.Subscriptions
{
    public class MessageSubscription
    {
        [Subscribe]
        [Topic]
        public Message OnMessageReceived([EventMessage] Message message)
        {
            return message;
        }
    }

    public class Message
    {
        public string Text { get; set; }
    }
}
