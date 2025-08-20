using AutoMapper;
using Domain.Models;
using Application.DTOs.Customers;
using Application.DTOs.Employees;
using Application.DTOs.Godowns;
using Application.DTOs.InwardTransactions;
using Application.DTOs.Items;
using Application.DTOs.OutwardTransactions;
using Application.DTOs.ReturnTransactions;
using Application.DTOs.Suppliers;
using Application.DTOs.Users;
using Application.DTOs.Reports;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer Mappings
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<CustomerDto, UpdateCustomerDto>().ReverseMap();

            // Employee Mappings
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<EmployeeDto, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UserListDto>().ReverseMap();

            // Godown Mappings
            CreateMap<Godown, GodownDto>().ReverseMap();
            CreateMap<Godown, CreateGodownDto>().ReverseMap();
            CreateMap<Godown, UpdateGodownDto>().ReverseMap();
            CreateMap<GodownDto, UpdateGodownDto>().ReverseMap();
            CreateMap<Godown, GodownReportDto>().ReverseMap();

            // InwardTransaction Mappings
            CreateMap<InwardTransaction, InwardTransactionDto>().ReverseMap();
            CreateMap<InwardTransaction, CreateInwardTransactionDto>().ReverseMap();
            CreateMap<InwardTransaction, UpdateInwardTransactionDto>().ReverseMap();
            CreateMap<InwardTransactionDto, UpdateInwardTransactionDto>().ReverseMap();

            // Item Mappings
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Item, CreateItemDto>().ReverseMap();
            CreateMap<Item, UpdateItemDto>().ReverseMap();
            CreateMap<ItemDto, UpdateItemDto>().ReverseMap();
            CreateMap<Item, StockReportDto>().ReverseMap();

            // OutwardTransaction Mappings
            CreateMap<OutwardTransaction, OutwardTransactionDto>().ReverseMap();
            CreateMap<OutwardTransaction, CreateOutwardTransactionDto>().ReverseMap();
            CreateMap<OutwardTransaction, UpdateOutwardTransactionDto>().ReverseMap();
            CreateMap<OutwardTransactionDto, UpdateOutwardTransactionDto>().ReverseMap();

            // ReturnTransaction Mappings
            CreateMap<ReturnTransaction, ReturnTransactionDto>().ReverseMap();
            CreateMap<ReturnTransaction, CreateReturnTransactionDto>().ReverseMap();
            CreateMap<ReturnTransaction, UpdateReturnTransactionDto>().ReverseMap();
            CreateMap<ReturnTransactionDto, UpdateReturnTransactionDto>().ReverseMap();

            // Supplier Mappings
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
            CreateMap<SupplierDto, UpdateSupplierDto>().ReverseMap();
        }
    }
}