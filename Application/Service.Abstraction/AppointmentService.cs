﻿using Application.IService.Abstraction;
using Application.Model.AppointmentModel;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AppointmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAppointmentAsync(CreateAppointmentModel createAppointmentModel)
        {
           var newAppointment=_mapper.Map<Appointment>(createAppointmentModel);
            newAppointment.AppointmentStatus = nameof(AppointmentStatus.Pending);
            await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
