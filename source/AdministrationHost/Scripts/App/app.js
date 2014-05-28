﻿/// <reference path="../Libs/angular.1.2.13.js" />
/// <reference path="../Libs/angular-route.js" />

(function (angular) {
    var app = angular.module("app", ['ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                controller: 'HomeCtrl',
                templateUrl: 'Templates/home.html'
            })
            .otherwise({
                redirectTo: '/'
            });
    });

    app.controller("AppCtrl", function ($scope) {
        $scope.model = {
            username : "Admin User"
        };
    });

    app.controller("HomeCtrl", function ($scope) {
        $scope.model = {};
    });
   
})(angular);
