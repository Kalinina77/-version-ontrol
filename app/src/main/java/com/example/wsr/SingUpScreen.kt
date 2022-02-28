package com.example.wsr

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.util.Patterns
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import com.google.firebase.auth.FirebaseAuth

class SingUpScreen : AppCompatActivity() {
    private lateinit var auth : FirebaseAuth
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sing_up_screen)
        var SignUp = findViewById<Button>(R.id.SignUp)

        var Name = findViewById<EditText>(R.id.Name)
        var Login = findViewById<EditText>(R.id.Login)
        var Password = findViewById<EditText>(R.id.Password)
        var ConfirmPassword = findViewById<EditText>(R.id.ConfirmPassword)

        SignUp.setOnClickListener {
            if (!Name.text.trim().isEmpty() && !Login.text.trim().isEmpty() && !Password.text.trim().isEmpty() && !ConfirmPassword.text.trim().isEmpty())
                if (isEmailValid(Login.text.toString()))
                    if (Password.text.toString() == ConfirmPassword.text.toString())
                    {
                        signUpUsers(Login.text.toString(), Password.text.toString())
                    }
                    else
                        Toast.makeText(baseContext, "Пароль не совпал =((( ${Login.text} ${ConfirmPassword.text}", Toast.LENGTH_LONG).show()
                else
                    Toast.makeText(baseContext, "Не знаю такой пoчты))", Toast.LENGTH_LONG).show()
            else
                Toast.makeText(baseContext, "Необходимо заполнить ВСЕЕЕЕ поля", Toast.LENGTH_LONG).show()
        }
        var Back = findViewById<Button>(R.id.Back)
        Back.setOnClickListener {
            finish()
        }
    }
    fun isEmailValid(email: String): Boolean {
        return Patterns.EMAIL_ADDRESS.matcher(email).matches()
    }

    private fun signUpUsers(login: String, password: String) {
        auth.createUserWithEmailAndPassword(login, password)
            .addOnCompleteListener(this) {
                if(it.isSuccessful){
                    Toast.makeText(baseContext, "Зарегистрировано", Toast.LENGTH_LONG).show()
                } else{
                    Toast.makeText(
                        baseContext, it.exception.toString(),
                        Toast.LENGTH_LONG
                    ).show()
                    Log.i("SignUpUsers", it.exception.toString())
                }
            }
    }
}