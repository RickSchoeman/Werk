using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Handlers.Dimension;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace DemoConnector.TwinfieldAPI.Handlers
{
    public class DimensionOperations : IDimensionOperations
    {
        private readonly DimensionService _dimensionService;
        private readonly List<object> _dimensionList = new List<object>();
        private const int SearchField = 0;

        public DimensionOperations(Session session)
        {
            _dimensionService = new DimensionService(session);
        }
        
        public List<object> GetByName(string name, string type)
        {
            _dimensionList.Clear();
            var objs = _dimensionService.FindDimensions(name, type, SearchField);
            foreach (var o in objs)
            {
                var obj = _dimensionService.ReadDimension(type, o.Code);
                _dimensionList.Add(obj);
            }

            return _dimensionList;
        }

        public List<object> GetAll(string type)
        {
            _dimensionList.Clear();
            var objs = _dimensionService.FindDimensions("*", type, SearchField);
            foreach (var o in objs)
            {
                var obj = _dimensionService.ReadDimension(type, o.Code);
                _dimensionList.Add(obj);
            }

            return _dimensionList;
        }

        public object Read(string type, string code)
        {
            try
            {
                return _dimensionService.ReadDimension(type, code);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Create(object obj)
        {
            try
            {
                _dimensionService.CreateDimension(obj);
                return "Created";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Delete(object obj)
        {
            try
            {
                _dimensionService.DeleteDimension(obj);
                return "Deleted";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Activate(object obj)
        {
            try
            {
                _dimensionService.ActivateDimension(obj);
                return "Activated";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
