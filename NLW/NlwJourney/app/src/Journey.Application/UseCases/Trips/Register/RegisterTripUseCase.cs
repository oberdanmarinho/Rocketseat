using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Nome não pode ser vazio");
        }

        if (request.StartDate < DateTime.UtcNow)
        {
            throw new ArgumentException("A viagem não pode ser registrada para uma data menor que a data atual");
        }

        if(request.EndDate >= request.StartDate)
        {
            throw new Exception("A viagem não pode começar antes da data de início");
        }
    }
}
