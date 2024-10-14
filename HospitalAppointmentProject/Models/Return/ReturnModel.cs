namespace HospitalAppointmentProject.Models.Return;

public class ReturnModel <T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    
    public ReturnModel(bool isSuccess, string message, T data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
    
    public override string ToString()
    {
        return $"IsSuccess: {IsSuccess}, Message: {Message}, Data: {Data}";
    }
}