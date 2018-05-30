using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.Dimensions;
using DemoConnector.TwinfieldAPI.Handlers.Dimension;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace DemoConnector.TwinfieldAPI.Handlers
{


    public class DimensionOperations<T> : IDimensionOperations<T> where T : class
    {
        private readonly DimensionService _dimensionService;
        private const int SearchField = 0;

        public DimensionOperations(Session session)
        {
            _dimensionService = new DimensionService(session);
        }
        
        public List<T> GetByName(string name, string type)
        {
            List<T> dimensionList = new List<T>();
            var objs = _dimensionService.FindDimensions(name, type, SearchField);
            foreach (var o in objs)
            {
                var obj = _dimensionService.ReadDimension<T>(o.Code);
                dimensionList.Add(obj);
            }

            return dimensionList;
        }

        public List<DimensionSummary> GetSummaries(string type)
        {
            return _dimensionService.FindDimensions("*", type, SearchField);
        }

        public List<T> GetAll(string type)
        {
            List<T> dimensionList = new List<T>();
            var objs = _dimensionService.FindDimensions("*", type, SearchField);
            foreach (var o in objs)
            {
                var obj = _dimensionService.ReadDimension<T>(o.Code);
                dimensionList.Add(obj);
            }

            return dimensionList;
        }

        public T Read(string type, string code)
        {
            try
            {
                return _dimensionService.ReadDimension<T>(code);
            }
            catch (Exception e)
            {
                return new ResultMessage{Code = e.Message} as T;
            }
        }

        public string Create(T obj)
        {
            try
            {
                _dimensionService.CreateDimension<T>(obj);
                return "Created";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Delete(T obj)
        {
            try
            {
                _dimensionService.DeleteDimension<T>(obj);
                return "Deleted";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Activate(T obj)
        {
            try
            {
                _dimensionService.ActivateDimension<T>(obj);
                return "Activated";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
