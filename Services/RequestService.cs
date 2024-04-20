using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAll();
        Request GetById(int id);
        Request Create(Request request);
        void Update(Request request);
        void Delete(int id);
    }

    public class RequestService : IRequestService
    {
        private readonly DataContext _context;

        public RequestService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Request> GetAll()
        {
            return _context.Requests;
        }

        public Request GetById(int id)
        {
            return _context.Requests.Find(id);
        }

        public Request Create(Request request)
        {
            request.Status = "created";
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public void Update(Request request)
        {
            var existingRequest = _context.Requests.Find(request.Id);
            if (existingRequest == null)
                throw new KeyNotFoundException("Request not found");

            if(existingRequest.Status != request.Status)
                existingRequest.Status = request.Status;

            _context.Requests.Update(existingRequest);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = _context.Requests.Find(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
        }
    }
}
