MyApp.controller("EditCustomersController", function ($scope, CustomerApi, $location) {



    $scope.UpdCust = function () {
        CustomerApi.UpdCustomer($scope.data.customers)
            .then(function (data) {
                alert("Customer updated");
                window.location = "/#!/ListCustomers.html";
            }, function (reponse) {
                alert("Error in updating customer");
            })
    }

    getCustomersById();
    function getCustomersById() {
        $scope.data = [];
        var path = $location.path();
        var id = path.split("/", 3)[2];
        CustomerApi.getCustomersById(id).then(function (data) {
            $scope.data.customers = data.data;
            $scope.data.customers.Profession = $scope.data.customers.Profession.toString(); 
        }, function (error) {
            $scope.status = 'Unable to load customers data: ' + error.message;
        })
    }

    getProfessions();
    function getProfessions() {
        $scope.data = [];
        CustomerApi.getProfessions().then(function (data) {
            $scope.data.profession = data.data;
        }, function (error) {
            $scope.status = 'Unable to load professions data: ' + error.message;
        })
    }

});