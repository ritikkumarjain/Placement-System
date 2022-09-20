import { useState, useRef } from "react";
import { useNavigate } from 'react-router-dom';
import LoginHeader from "../Header/LoginHeader";
import Footer from "../Footer/Footer";
import "./Authorization.css";
import * as React from 'react';
import AuthorizationForm from "./AuthorizationForm";


function Authorization() {
    const [universityId, setId] = useState("");
    const [password, setPassword] = useState("");
    const [alertBool, setAlertBool] = useState(false);
    const navigate = useNavigate();
    const formRef = useRef(null);



    async function handleSubmit(e) {
        e.preventDefault();


        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            return;
        }

        let postData = { universityId, password };
        await fetch("https://localhost:44330/api/Authorization", {
            method: "POST",
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify(postData)
        })
            .then(response => response.json())
            .then(data => {
                if (data.status === 404) {
                    alert("Something went wrong");
                    return;
                }
                setAlertBool(false);
                localStorage.setItem("user-info", JSON.stringify(data));
                if (localStorage.getItem("user-info") == null) {
                    navigate("/");
                }
                else if (JSON.parse(localStorage.getItem("user-info")).message === "Invalid Password") {
                    setAlertBool(true);
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).message === "Invalid Id") {
                    setAlertBool(true);
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).identity === "Student") {
                    navigate("/students-menu/");
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).identity === "Coordinator") {
                    navigate("/coordinators-menu/");
                    return;
                }
            })
            .catch(error => {
                alert("Something went wrong");
                window.location.reload();
            })

    }


    function NavigateToSignup() {

        navigate("/signup/");
        return;
    }



    return (
        <>
            <LoginHeader />

            <AuthorizationForm/>




            <Footer />

        </>
    );
}

export default Authorization;