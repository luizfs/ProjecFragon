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

    $scope.delete = function (id) {
        CustomerApi.DeleteCustomer(id);
        alert("Cliente deletado com sucesso!");
        setTimeout(function () { getCustomers(); }, 200);
    }

    getCustomersById();
    function getCustomersById(id) {
        $scope.data = [];
        CustomerApi.getCustomersById(id).then(function (data) {
            $scope.data.customers = data.data;
        }, function (error) {
            $scope.status = 'Unable to load customer data: ' + error.message;
        })
    }


});
