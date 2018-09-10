MyApp.controller("EditCustomersController", function ($scope, CustomerApi, $location) {
    $scope.showmsg = false;
    $scope.showmsgerro = false;
    $scope.showmsgerroi = false;

    $scope.UpdCust = function () {
        $scope.showmsg = false;
        $scope.showmsgerro = false;
        $scope.showmsgerroi = false;
        if ($scope.data.customers.FirstName == "" || $scope.data.customers.LastName == "" || $scope.data.customers.CPF == "" || $scope.data.customers.BirthDate == "") {
            $scope.showmsgerro = true;
            return
        }
        CustomerApi.UpdCustomer($scope.data.customers)
            .then(function (data) {
                $scope.showmsg = true;
            }, function (reponse) {
                $scope.showmsgerroi = true;
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
            $scope.data.customers.BirthDate = new Date($scope.data.customers.BirthDate).toLocaleString("pt-BR");
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