MyApp.controller("AddCustomersController", function ($scope, CustomerApi) {
    $scope.customer = {};
    $scope.showmsg = false;
    $scope.showmsgerro = false;
    $scope.showmsgerroi = false;
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
        $scope.showmsg = false;
        $scope.showmsgerro = false;
        $scope.showmsgerroi = false;
        if ($scope.customer.FirstName == "" || $scope.customer.LastName == "" || $scope.customer.CPF == "" || $scope.customer.BirthDate == "") {
            $scope.showmsgerro = true;
            return
        }
        CustomerApi.AddCustomer($scope.customer)
            .then(function (data) {
                $scope.showmsg = true;
                $scope.startFront();
            }, function (reponse) {
                $scope.showmsgerroi = true;
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
