using EventOrchestrationService.Api.GraphQL.Subscriptions;
using HotChocolate.Subscriptions;

namespace EventOrchestrationService.Api.GraphQL.Mutations
{
    public class MessageMutation
    {
        public async Task<Message> SendMessage(string text, [Service] ITopicEventSender eventSender)
        {
            var message = new Message { Text = text };
            await eventSender.SendAsync(nameof(MessageSubscription.OnMessageReceived), message);
            return message;
        }
    }
}
