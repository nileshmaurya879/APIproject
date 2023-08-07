using Microsoft.AspNetCore.Mvc;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Domain.Model;
using Pagination_Project.API.Infrastructure;
using Pagination_Project.API.Infrastructure.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace Pagination_Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private ICustomerDataAccess _icustomerDataAccess;
        public CustomerController(ICustomerDataAccess customerDataAccess) : base(customerDataAccess)
        {
            _icustomerDataAccess = customerDataAccess;
        }

        [HttpGet]
        public ActionResult GetCustomer([FromQuery] PageFilter pageFilter)
        {
            if (IsValidData(pageFilter, Operations.View, EntityType.Customer, out ValidationReturn validation))
            {
                var customers = _icustomerDataAccess.GetCustomers(pageFilter);
                return Ok(new Response<CustomerDto>(customers));
            }
            else
                return StatusCode((int)HttpStatusCode.OK, validation);
        }

        [HttpPost]
        public ActionResult Add([FromBody] IEnumerable<CustomerForCreationDto> customer)
        {
            if (customer != null)
            {
                var data = _icustomerDataAccess.AddCustomer(customer);
                return Ok(new Response<Customer>(data));

            }
            else
                return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(CustomerForUpdateDto customer)
        {
            if (customer != null)
            {
                var data = _icustomerDataAccess.UpdateCustomer(customer);
                return Ok(new Response<CustomerDto>(data));
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            var result = _icustomerDataAccess.DeleteCustomer(id);
            return Ok(new Response<CustomerDto>(result));
        }

        [HttpPut("UpdateCustomerData")]

        public ActionResult UpdateCustomerData(CustomerForUpdateDto customer)
        {
            if (customer != null)
            {
                var currentdata = _icustomerDataAccess.GetCustomer(customer.CustomerId);

                customer.Current = currentdata;

                var result = _icustomerDataAccess.UpdateCustomerData(customer);
                return Ok(new Response<Customer>(result));
            }
            return Ok(new Response<Customer>(false));
        }

        [HttpPut("UpdateCustomerDataSingle")]

        public ActionResult UpdateCustomerDataSingle([FromBody] IEnumerable<CustomerForUpdateDto> customer)
        {
            if (customer != null)
            {
                var currentdata = _icustomerDataAccess.GetCustomer(customer.FirstOrDefault().CustomerId);

                var result = _icustomerDataAccess.UpdateCustomerDataSingle(customer);
                return Ok(new Response<Customer>(result));
            }
            return Ok(new Response<Customer>(customer));
        }

        [HttpGet("ReadXMlFileData")]
        public ActionResult ReadXMlFileData()
        {
            XmlDocument xmlDcoument = new XmlDocument();

            xmlDcoument.Load(@"XMLFile.xml");

            XmlNodeList? xmlNodeList = xmlDcoument.DocumentElement.SelectNodes("/InventoryResponse/Item");

            Console.WriteLine("Output using XMLDocument");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                var val1 = xmlNode.SelectSingleNode("ItemID").InnerText;
                var val2 = xmlNode.SelectSingleNode("CaseQty").InnerText;
                var val3 = xmlNode.SelectSingleNode("BottleQty").InnerText;

            }

            return BadRequest();
        }

        [HttpPost("ReadXMlStringData")]
        public ActionResult ReadXMlStringData(string test)
        {
            XmlDocument xmlDcoument = new XmlDocument();

            var data = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<InventoryResponse>\r\n    <Item>\r\n        <ItemID>22699</ItemID>\r\n        <CaseQty>34</CaseQty>\r\n        <BottleQty>834</BottleQty>\r\n    </Item>\r\n    <Item>\r\n        <ItemID>45179</ItemID>\r\n        <CaseQty>30</CaseQty>\r\n        <BottleQty>364</BottleQty>\r\n    </Item>\r\n    <Item>\r\n        <ItemID>32102</ItemID>\r\n        <CaseQty>19</CaseQty>\r\n        <BottleQty>234</BottleQty>\r\n    </Item>\r\n    <Item>\r\n        <ItemID>11460</ItemID>\r\n        <CaseQty>50</CaseQty>\r\n        <BottleQty>600</BottleQty>\r\n    </Item>\r\n</InventoryResponse>";

            xmlDcoument.LoadXml(data);

            XmlNodeList? xmlNodeList = xmlDcoument.DocumentElement.SelectNodes("/InventoryResponse/Item");

            Console.WriteLine("Output using XMLDocument");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                var val1 = xmlNode.SelectSingleNode("ItemID").InnerText;
                var val2 = xmlNode.SelectSingleNode("CaseQty").InnerText;
                var val3 = xmlNode.SelectSingleNode("BottleQty").InnerText;

            }

            return BadRequest();
        }

        [HttpGet("GetCustomerById")]
        public ActionResult GetCustomer([FromQuery] int id)
        {
                var customers = _icustomerDataAccess.GetCustomer(id);
                return Ok(new Response<CustomerDto>(customers));
          
        }

        [HttpGet("GetCustomerUsingSp")]
        public ActionResult GetCustomerUsingSp()
        {
            var data = _icustomerDataAccess.GetCustomerUsingSp();
            return Ok(data);
        }
        [HttpGet("GetCustomerUsingSpById")]
        public ActionResult GetCustomerUsingSpById(int Id,string name)
        {
            var data = _icustomerDataAccess.GetCustomerUsingSpById(Id,name);
            return Ok(data);
        }
    }
}
