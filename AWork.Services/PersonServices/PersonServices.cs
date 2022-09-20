﻿using AutoMapper;
using AWork.Contracts.Dto;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction;
using AWork.Services.Abstraction.PersonModul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.PersonServices
{
    public class PersonServices : IPersonServices
    {
        private IPersonRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonServices(IPersonRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Delete(PersonDto personDto)
        {
            var personMdl = _mapper.Map<Person>(personDto);
            _repositoryManager._personRepository.Remove(personMdl);
            _repositoryManager.SaveAsync();
        }

        public void Edit(PersonDto personDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonDto>> GetAllPerson(bool trackChanges)
        {
            var personMdl = await _repositoryManager._personRepository.GetAllPerson(trackChanges);
            var personDto = _mapper.Map<IEnumerable<PersonDto>>(personMdl);
            return personDto;
        }

        public async Task<PersonDto> GetAllPersonById(int personId, bool trackChanges)
        {
            var personMdl = await _repositoryManager._personRepository.GetPersonById(personId, trackChanges);
            var personDto = _mapper.Map<PersonDto>(personMdl);
            return personDto;
        }

        public void Insert(PersonForCreateDto personForCreateDto)
        {
            var personMdl = _mapper.Map<Person>(personForCreateDto);
            _repositoryManager._personRepository.Insert(personMdl);
            _repositoryManager.Save();
        }
    }
}
