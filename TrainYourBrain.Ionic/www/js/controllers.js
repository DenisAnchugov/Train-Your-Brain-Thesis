angular
    .module("trainBrain.controllers", [])
    .controller("ExpressionController", ExpressionController);

function ExpressionController($interval, $ionicPopup, expressionService) {
    var timer;
    var vm = this;
    vm.isInputDisabled = true;

    var timerTick = function () {
        vm.timer--;
        if (vm.timer === 0) {
            vm.lives--;
            vm.deployExpression();
            vm.timer = 5;
        }
    };

    vm.deployExpression = function () {
        if (vm.lives > 0) {
            vm.currentExpression = expressionService.getExpression();
        } else {
            vm.showAlert();
            $interval.cancel(timer);
        }
    };

    vm.eraseChar = function () {
        if (vm.userInput.length !== 0) {
            vm.userInput = vm.userInput.slice(0, -1);
        }
    };

    vm.appendChar = function (char) {
        vm.userInput = vm.userInput + char;
    };

    vm.checkAnswer = function () {
        var isCorrect = vm.currentExpression.checkAnswer(parseInt(vm.userInput));

        if (isCorrect) {
            vm.score++;
        } else {
            vm.lives--;
        }

        vm.timer = 5;
        vm.userInput = '';
        vm.deployExpression();
    };

    vm.start = function () {
        expressionService.reset();
        init(vm);
        if (timer) {
            $interval.cancel(timer);
        }
        timer = $interval(timerTick, 1000);
    };

    vm.showAlert = function () {
        var alertPopup = $ionicPopup.alert({
            title: "Game Over",
            template: "Your score: " + vm.score
        });

        alertPopup.then(function () {
            vm.isInputDisabled = true;
        });
    };
}

var init = function (scope) {
    scope.timer = 5;
    scope.score = 0;
    scope.lives = 3;
    scope.userInput = "";
    scope.isInputDisabled = false;
    

    scope.deployExpression();
};
