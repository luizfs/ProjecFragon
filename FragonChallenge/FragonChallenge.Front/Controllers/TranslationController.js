MyApp.controller('TranslationController', ['$scope', '$translate', function ($scope, $translate) {

    $scope.changeLanguage = function (language) {
        $translate.use(language);
    }

}]);