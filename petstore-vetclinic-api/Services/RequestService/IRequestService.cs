using petstore_vetclinic_api.Models.Clinic;

namespace petstore_vetclinic_api.Services.RequestService
{
    public interface IRequestService
    {
        Task<List<Request>> GetAllRequest();
        Task<List<Request>?> AddRequests(Request request);
        Task<List<Request>?> UpdateRequest(int id, Request request);
        Task<List<Request>?> DeleteRequest(int id);
    }
}
