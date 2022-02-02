using System;
using System.Collections.Generic;
using Server.Exceptions;
using Server.InitialisingInterfaces;
using Server.GeneralInterfaces;

namespace App.Services
{
    /// <summary>
    /// Class which stores objects of IService to be used within the program
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class ServiceLocator : IService, IInitialiseParam<IFactory<IService>>, IServiceLocator
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IService>, name it '_serviceDict':
        private IDictionary<string, IService> _serviceDict;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ServiceLocator
        /// </summary>
        public ServiceLocator()
        {
            // INSTANTIATE _serviceDict as a new Dictionary<string, IService>():
            _serviceDict = new Dictionary<string, IService>();
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IFACTORY<SERVICE>>

        /// <summary>
        /// Initialises an object with a reference to an IService instance
        /// </summary>
        /// <param name="pServiceFactory"> IFactory<IService> instance </param>
        public void Initialise(IFactory<IService> pServiceFactory)
        {
            // IF pServiceFactory DOES HAVE an active instance:
            if (pServiceFactory != null)
            {
                // DECLARE & INITIALISE a string, name it '_serviceName', give value of incoming class' type:
                string _serviceName = pServiceFactory.GetType().Name;


                Console.WriteLine(_serviceName);

                // ADD new service to _serviceDict, with type of pServiceFactory as key, and pServiceFactory as value:
                _serviceDict.Add(_serviceName, pServiceFactory as IService);
            }
            // IF pServiceFactory DOES NOT HAVE an active instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: pServiceFactory does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ISERVICELOCATOR

        /// <summary>
        /// Returns an instance of an IService object specified in place of the generic 'C'
        /// </summary>
        /// <typeparam name="C"> Generic for Class needed </typeparam>
        /// <returns> Instance of IService </returns>
        public IService GetService<C>() where C : IService, new()
        {
            // DECLARE & INITIALISE a string, name it '_serviceName', give value of incoming class/interface:
            string _serviceName = "" + typeof(C);

            // IF _serviceDict DOES NOT contain a key of name of class/interface to be created:
            if (!_serviceDict.ContainsKey(_serviceName))
            {
                // TRY checking if Create() throws a ClassDoesNotExistException:
                try
                {
                    // ADD new service to _serviceDict, with type 'C' name as key, and instance of a type 'C' factory as value:
                    _serviceDict.Add(_serviceName, (_serviceDict["Factory`1"] as IFactory<IService>).Create<C>());
                }
                // CATCH KeyNotFoundException from _serviceDict["Factory<IService>"]:
                catch (KeyNotFoundException e)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(e.Message);
                }
                // CATCH ClassDoesNotExistException from Create():
                catch (ClassDoesNotExistException e)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(e.Message);
                }
            }

            // RETURN instance of current _serviceName in _serviceDict:
            return _serviceDict[_serviceName];
        }

        #endregion
    }
}
