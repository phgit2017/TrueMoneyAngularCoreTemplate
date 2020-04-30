var app = angular.module('MyApp', []);

app.controller('MyController', function ($scope, $http) {
    $scope.MyVal = 'Welcome to Angular';
});