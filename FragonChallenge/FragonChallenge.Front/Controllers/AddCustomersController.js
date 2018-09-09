MyApp.controller("AddCustomersController", function ($scope, CustomerApi) {
    $scope.customer = {};

    $scope.startFront = function () {
        $scope.customer = {
            'FirstName': "",
            'LastName': "",
            'CPF': "",
            'BirthDate': "",
            'Profession': ""
        };
    }

    $scope.AddCust = function () {
        CustomerApi.AddCustomer($scope.customer)
            .then(function (data) {
                alert("Customer added");
                $scope.startFront();
            }, function (reponse) {
                alert("Error in adding customer");
            })
    }

    $scope.startFront();
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
