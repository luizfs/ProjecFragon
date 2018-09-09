MyApp.controller("ListCustomersController", function ($scope, CustomerApi) {
    getCustomers();
    function getCustomers() {
        $scope.data = [];
        CustomerApi.getCustomers().then(function (data) {
            $scope.data.customers = data.data;
        }, function (error) {
            $scope.status = 'Unable to load customers data: ' + error.message;
        })            
    }
});
