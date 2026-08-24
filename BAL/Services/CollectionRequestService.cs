using AutoMapper;
using BAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class CollectionRequestService
    {

        CollectionRequestRepo repo;
        IMapper mapper;

        public CollectionRequestService(CollectionRequestRepo repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        

        public List<CollectionRequestModel> GetAllCollectionRequest() {

            var allcollectionreq = repo.GetAllCollectionRequests();
            return mapper.Map<List<CollectionRequestModel>>(allcollectionreq);
        
        }

        public CollectionRequestModel GetSingleCollectionReq(int id) {
        
            var result=repo.GetCollectionRequestById(id);
            return mapper.Map<CollectionRequestModel>(result);
        
        
        }

        public bool AddCollectionReq(CollectionRequestModel collectionRequestmodel)
        {
            var collectionRequest = mapper.Map<DAL.EF.Tables.CollectionRequest>(collectionRequestmodel);
            return repo.AddCollectionRequest(collectionRequest);
        }

        public bool UpdateCollectionReq(CollectionRequestModel CollectionReqModel)
        {
            var CollectionReq = mapper.Map<DAL.EF.Tables.CollectionRequest>(CollectionReqModel);
            return repo.ModifyCollectionRequest(CollectionReq);
        }

        public bool DeleteCollectionReq(int id)
        {
            return repo.DeleteCollectionRequest(id);

        }



        public bool AssignToEmployee(int collectionRequestId, int employeeId)
        {
            return repo.AssingToEmployee(collectionRequestId, employeeId);
        }

        public bool FoodDeliverd(int collectionRequestId)
        {
            return repo.FoodDeliverd(collectionRequestId);
        }

        public List<object> GetDeliverySummary()
        {
            return repo.GetDeliverySummary();
        }   

    }
}
