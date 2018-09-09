/// <reference path="../scripts/angular.js" />

var CustomerService = angular.module('CustomerService', []);

CustomerService.factory('CustomerApi', function ($http) {
    var urlBase = "http://localhost:31766/api";
    var CustomerApi = {};
    
    CustomerApi.getCustomers = function () {
        return $http.get(urlBase + '/Customer/Get');
    };

    CustomerApi.AddCustomer = function (customer) {
        //alert(customer);
        //var req = $http({
        //    method: 'post',
        //    url: urlBase + '/Customer',
        //    data: customer
        //});
        //return req;
        return $http.post(urlBase + '/Customer/', customer);
    };


    CustomerApi.EditCustomer = function (customerToUpdate) {

        var request = $http({
            method: 'put',
            url: urlBase + '/Customer/' + customerToUpdate.CustomerId,
            data: customer
        });
        return request;
    };

    CustomerApi.DeleteCustomer = function (customerIdToDelete) {
        var request = $http({
            method: 'delete',
            url: urlBase + '/Customer/' + customerId.customerIdToDelete.CustomerId
        });

        return request;
    };

    return CustomerApi;
});
