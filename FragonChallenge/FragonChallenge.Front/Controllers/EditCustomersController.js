MyApp.controller("EditCustomersController", function ($scope, CustomerApi, $location) {

    $scope.customer = {};

    $scope.startFront = function () {
        $scope.customer = {
            'data.customers.FirstName': "",
            'data.customers.LastName': "",
            'data.customers.CPF': "",
            'data.customers.BirthDate': "",
            'data.customers.Profession': ""
        };
    }

    $scope.UpdCust = function () {
        CustomerApi.UpdCustomer($scope.customer)
            .then(function (data) {
                alert("Customer updated");
                $scope.startFront();
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