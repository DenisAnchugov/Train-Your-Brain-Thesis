angular.module("trainBrain.services", [])
       .factory("expressionFactory", expressionFactory);

var operators = ["+", "-"];

function expressionFactory() {
    var numberRange = 8;

    var createExpression = function () {
        var a = Math.floor(Math.random() * numberRange);
        var b = Math.floor(Math.random() * numberRange);
        var operator = operators[Math.floor(Math.random() * operators.length)];

        return new Expression(a, b, operator);
    };

    return {
        getExpression: function () {
            numberRange++;
            return createExpression();
        },
        reset: function () {
            numberRange = 8;
        }
    };
};

function Expression(a, b, operator) {

    function toString() {
        return a.toString() + operator.toString() + b.toString() + '=';
    };

    function checkAnswer(userAnswer) {
        return calculate() === userAnswer;
    };

    function calculate() {
        switch (operator) {
            case "+":
                return a + b;
            case "-":
                return a - b;
        }
    };

    return {
        checkAnswer: checkAnswer,
        toString: toString
    };
};
