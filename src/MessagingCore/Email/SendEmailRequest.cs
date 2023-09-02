namespace MessagingCore.Email;

public record SendEmailRequest(string To, string Subject, string Body);