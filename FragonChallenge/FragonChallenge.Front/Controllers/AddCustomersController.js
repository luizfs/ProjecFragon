MyApp.controller("AddCustomersController", function ($scope, CustomerApi) {
    $scope.AddCust = function () {
        var customerToAdd = {
            'FirstName': $scope.FirstName,
            'LastName': $scope.LastName,
            'CPF': $scope.CPF,
            'BirthDate': $scope.BirthDate,
            'Profession': $scope.Profession
        };

        CustomerApi.AddCustomer(customerToAdd).then(function (response) {
            alert("Customer added");
            $scope.FirstName = undefined;
            $scope.LastName = undefined;
            $scope.CPF = undefined;
            $scope.BirthDate = undefined;
            $scope.Profession = undefined;
        }, function (reponse) {
            alert("Error in adding customer");
        })         
    }
});
