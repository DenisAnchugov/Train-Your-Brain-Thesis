angular.module("trainBrain", ["ionic", "trainBrain.controllers", "trainBrain.services"])

.run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
        if (window.StatusBar) {
            window.StatusBar.styleLightContent();
        }
    });
})

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider.state("main", {
        url: "/main",
        templateUrl: "templates/main-page.html",
        controller: "expressionController"
    });

    $urlRouterProvider.otherwise("/main");
});
