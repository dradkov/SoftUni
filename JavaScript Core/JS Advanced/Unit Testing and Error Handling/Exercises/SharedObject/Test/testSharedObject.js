let expect = require('chai').expect;
let sharedObject = require("../shared-object").sharedObject;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

document.body.innerHTML = `<div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>`;

describe('sharedObject', function () {
  before(() => global.$ = $);

  //check for properties initial state
  describe('initial name and income should be null', function () {
    it("should return null for initial state of name", function () {
      expect(sharedObject.name).to.be.null;
    });
    it("should return null for initial state of income", function () {
      expect(sharedObject.income).to.be.null;
    });

  });
  //check change name function
  describe("change name function", function () {
    it("sharedObject's name property and the name textbox's value should be set to the passed in parameter", function () {
      sharedObject.changeName('test');
      expect(sharedObject.name).to.equal('test');
      expect($('#name').val()).to.equal('test');
    });
    it("should return previous name for empty string parameter", function () {
      sharedObject.changeName("Previous");
      sharedObject.changeName("");
      expect(sharedObject.name).to.equal("Previous");
      expect($('#name').val()).to.equal("Previous");
    });
    it("should return new name after calling the function more than one time", function () {
      sharedObject.changeName("Previous");
      sharedObject.changeName("NewName");
      expect(sharedObject.name).to.equal("NewName");
      expect($('#name').val()).to.equal("NewName");
    });
  });
  //check change income function
  describe("changeIncome function", function () {
    it("should return previous value after calling with 0 parameter", function () {
      sharedObject.changeIncome(15);
      sharedObject.changeIncome(0);
      expect(sharedObject.income).to.equal(15);
      expect($('#income').val()).to.equal("15");
    });
    it("should return correct result after calling with integer", function () {
      sharedObject.changeIncome(20);
      expect(sharedObject.income).to.equal(20);
      expect($('#income').val()).to.equal("20");
    });
    it("should return previous value after calling with negative parameter", function () {
      sharedObject.changeIncome(5);
      sharedObject.changeIncome(-10);
      expect(sharedObject.income).to.equal(5);
      expect($('#income').val()).to.equal("5");
    });
  });
  //check update name function
  describe("updateName function", function () {
    it("should successfully change name with non empty string", function () {
      sharedObject.changeName("Previuos");
      $("#name").val("NewName");
      sharedObject.updateName();
      expect(sharedObject.name).to.equal("NewName");
      expect($("#name").val()).to.equal("NewName");
    });
    it("should not change name with empty string", function () {
      sharedObject.changeName("Previuos");
      $("#name").val("");
      sharedObject.updateName();
      expect(sharedObject.name).to.equal("Previuos");
      expect($("#name").val()).to.equal("");
    });
  });
  //check update income function
  describe("updateIncome function", function () {
    it("should return previous value if value is NaN", function () {
      sharedObject.changeIncome(15);
      $("#income").val("abc");
      sharedObject.updateIncome();
      expect(sharedObject.income).to.equal(15);
      expect($("#income").val()).to.equal("abc");
    });
    it("should return previous value if value is floating point number", function () {
      sharedObject.changeIncome(15);
      $("#income").val("3.6");
      sharedObject.updateIncome();
      expect(sharedObject.income).to.equal(15);
      expect($("#income").val()).to.equal("3.6");
    });
    it("should return previous value if value is negative number", function () {
      sharedObject.changeIncome(15);
      $("#income").val("-10");
      sharedObject.updateIncome();
      expect(sharedObject.income).to.equal(15);
      expect($("#income").val()).to.equal("-10");
    });
    it("should return previous value if value is 0", function () {
      sharedObject.changeIncome(15);
      $("#income").val("0");
      sharedObject.updateIncome();
      expect(sharedObject.income).to.equal(15);
      expect($("#income").val()).to.equal("0");
    });
    it("should return correct value id value is positive integer", function () {
      sharedObject.changeIncome(15);
      $("#income").val("20");
      sharedObject.updateIncome();
      expect(sharedObject.income).to.equal(20);
      expect($("#income").val()).to.equal("20");
    });
  });
});