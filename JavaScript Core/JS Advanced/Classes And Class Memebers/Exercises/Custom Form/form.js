let result =  (function () {
    class Textbox {
        constructor(selector, regex) {
            this.selector = selector;
            this._elements = $(selector);
            this._invalidSymbols = regex;
            this._value = '';
 
            let that = this;
            $(selector).on('input change', function () {
                let value = $(this).val();
                $(that.selector).val(value);
                that.value = value;
            });
        }
 
        get elements() { return this._elements }
 
        get value() { return this._value }
        set value(v) {
            this._value = v;
            $(this.selector).val(v);
        }
 
        isValid() { return !this._invalidSymbols.test($(this.selector).val()); }
    }
 
    class Form {
        constructor() {
            this._element = $('<div>').addClass('form');
            this._textboxes = [];
            for (let a of arguments) {
                if (!(a instanceof Textbox))
                    throw new Error(`Element is not a Textbox`);
            }
            for (let a of arguments) {
                this._element.append($(a.selector));
                this._textboxes.push(a);
            }
        }
        submit() {
            let allValid = true;
            for (let tb of this._textboxes) {
                if (tb.isValid()) {
                    $(tb.selector).css('border', '2px solid green');
                } else {
                    $(tb.selector).css('border', '2px solid red');
                    allValid = false
                }
            }

            return allValid
        }
        attach(selector) {
            $(selector).append(this._element);
        }
    }
 
    return {
        Textbox: Textbox,
        Form: Form
    }
})()

let Textbox = result.Textbox;
  let Form = result.Form;
  let username = new Textbox("#username",/[^a-zA-Z0-9]/);
  let password = new Textbox("#password",/[^a-zA-Z]/);
  username.value = "username";
  password.value = "password2";
  let form = new Form(username,password);
  form.attach("#root");
