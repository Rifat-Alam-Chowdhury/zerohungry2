using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class CollectionRequestRepo
    {

        FoodmanagmentsystemContext db;

        public CollectionRequestRepo( FoodmanagmentsystemContext db)
        {
            this.db = db;
            
        }


        public List<CollectionRequest> GetAllCollectionRequests()
        {
            return db.CollectionRequests.ToList();
        }

        public CollectionRequest GetCollectionRequestById(int id)
        {
            return db.CollectionRequests.Find(id);
        }

        public bool AddCollectionRequest(CollectionRequest collectionRequest)
        {
            db.CollectionRequests.Add(collectionRequest);
            return db.SaveChanges() > 0;
        }

        public bool ModifyCollectionRequest(CollectionRequest collectionRequest) {
        
        
            db.CollectionRequests.Update(collectionRequest); return db.SaveChanges() > 0;
        
        }
        public bool DeleteCollectionRequest(int id)
        {

            var collectionRequest = db.CollectionRequests.Find(id);
            db.CollectionRequests.Remove(collectionRequest); return db.SaveChanges() > 0;

        }

        public bool AssingToEmployee(int collectionRequestId, int employeeId)
        {
            var collectionRequest = db.CollectionRequests.Find(collectionRequestId);
            if (collectionRequest != null)
            {
                collectionRequest.EmployeeId = employeeId;
                collectionRequest.Status = "Assigned";
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool FoodDeliverd(int collectionRequestId)
        {
            var collectionRequest = db.CollectionRequests.Find(collectionRequestId);
            if (collectionRequest != null)
            {
                collectionRequest.Status = "Delivered";
                return db.SaveChanges() > 0;
            }
            return false;
        }

        //summary of delivered foods with restaurant name, employee name, and food details

        public List<object> GetDeliverySummary()
        {
            return db.CollectionRequests
                .Where(cr => cr.Status == "Delivered")
                .Select(cr => new
                {
                    CollectionRequestId = cr.CollectionReqId,
                    Restaurant = cr.Restaurant.Name,
                    DeliveredBy = cr.Employee.EmployeeName,
                    Foods = cr.Foods,
                    RequestDate = cr.RequestDate,
                    FreshTime = cr.FreshTime
                })
                .ToList<object>();
        }

    }
}
