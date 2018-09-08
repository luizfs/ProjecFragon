/// <reference path="scripts/angular.js" />

var MyApp = angular.module("MyApp", ['ngRoute']);

MyApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/AddCustomers', {
                templateUrl: 'Views/AddCustomers.html',
                controller: 'AddCustomersController'
            }).
            when('/ListCustomers', {
                templateUrl: 'Views/ListCustomers.html',
                controller: 'ListCustomersController'
            }).
            when('/Home', {
                templateUrl: 'Views/Home.html',
                controller: 'HomeController'
            }).
            otherwise({
                redirectTo: '/Home'
            });
    }
]);

MyApp.controller("AddCustomersController", function ($scope) {
    $scope.message = "Add Customers";
});
MyApp.controller("ListCustomersController", function ($scope) {
    $scope.message = "List Customers";
});
MyApp.controller("HomeController", function ($scope) {
    $scope.message = "Home Customers";
});