﻿using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.Infrastructure;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Domain.Entities;
using Saul.Test.Domain.Events;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Application.UseCases.Discounts
{
    public class DiscountsApplication : IDiscountsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly INotification _notification;

        public DiscountsApplication(IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus, INotification notification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventBus = eventBus;
            _notification = notification;
        }

        public async Task<Response<bool>> Insert(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.Insert(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data saved";

                    // Publishing Event
                    var discountCreatedEvent = _mapper.Map<DiscountCreatedEvent>(discount);
                    _eventBus.Publish(discountCreatedEvent);

                    // Send Email
                    await _notification.SendMail(response.Message, JsonSerializer.Serialize(response), cancellationToken);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                await _notification.SendMail(response.Message, JsonSerializer.Serialize(response.Message), cancellationToken);
            }
            return response;
        }

        public async Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.Update(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data Updated";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                await _unitOfWork.Discounts.Delete(id.ToString());
                response.Data = await _unitOfWork.Save(cancellationToken) >= 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data Deleted";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DiscountDto>();
            try
            {
                var discount = await _unitOfWork.Discounts.Get(id, cancellationToken);
                if (discount is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Discount not found";
                    return response;
                }
                response.Data = _mapper.Map<DiscountDto>(discount);
                response.IsSuccess = true;
                response.Message = "Discount found";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DiscountDto>>();
            try
            {
                var discounts = await _unitOfWork.Discounts.GetAll(cancellationToken);
                if (discounts is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Discounts not found";
                    return response;
                }
                response.Data = _mapper.Map<List<DiscountDto>>(discounts);
                response.IsSuccess = true;
                response.Message = "Discounts found";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<DiscountDto>>();
            try
            {
                var discounts = await _unitOfWork.Discounts.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<DiscountDto>>(discounts);
                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalCount = await _unitOfWork.Discounts.Count();
                    response.TotalPages = (int)Math.Ceiling(response.TotalCount / (double)pageSize);

                    response.IsSuccess = true;
                    response.Message = "Successful query";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
