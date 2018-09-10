/// <reference path="../scripts/angular.js" />

var CustomerService = angular.module('CustomerService', []);

CustomerService.factory('CustomerApi', function ($http) {
    var urlBase = "http://localhost:31766/api";
    var CustomerApi = {};
    
    CustomerApi.getCustomers = function () {
        return $http.get(urlBase + '/Customer');
    };

    CustomerApi.getCustomersById = function (idp) {
        return $http.get(urlBase + '/Customer/' + idp);
    };

    CustomerApi.getProfessions = function () {
        return $http.get(urlBase + '/Profession');
    };

    CustomerApi.getProfessionsByid = function (id) {
        return $http.get(urlBase + '/Profession/' + id);
    };
    CustomerApi.AddCustomer = function (customer) {
        return $http.post(urlBase + '/Customer', customer, {
            headers: { 'Content-Type': 'application/json' }
        })
    };

    CustomerApi.UpdCustomer = function (customer) {
        return $http.put(urlBase + '/Customer', customer, {
            headers: { 'Content-Type': 'application/json' }
        })
    };


    CustomerApi.DeleteCustomer = function (customerIdToDelete) {
        var request = $http({
            method: 'delete',
            url: urlBase + '/Customer/' + customerIdToDelete
        });

        return request;
    };

    return CustomerApi;
});
