import React from 'react';
import "./AuthorizationForm.css";
import { useState, useRef } from "react";
import { useNavigate } from 'react-router-dom';
import ClimbingBoxLoader from "react-spinners/ClimbingBoxLoader";




function AuthorizationForm() {

    const [universityId, setId] = useState("");
    const [password, setPassword] = useState("");
    const [alertBool, setAlertBool] = useState(false);
    const navigate = useNavigate();
    const formRef = useRef(null);
    const [loading, setLoading] = useState(false);



    async function handleSubmit(e) {
        setLoading(true);
        e.preventDefault();


        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            setLoading(false);
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
                    setLoading(false);
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).message === "Invalid Id") {
                    setAlertBool(true);
                    setLoading(false);
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).identity === "Student") {
                    navigate("/students-menu/");
                    setLoading(false);
                    return;
                }
                else if (JSON.parse(localStorage.getItem("user-info")).identity === "Coordinator") {
                    navigate("/coordinators-menu/");
                    setLoading(false);
                    return;
                }
            })
            .catch(error => {
                alert("Something went wrong");
                setLoading(false);
                window.location.reload();
            })

    }


    function NavigateToSignup() {

        navigate("/signup/");
        return;
    }


    return (
        <>
            <div className="logo text-center">
                <h1 className="lead display-3">Placement System</h1>
            </div>
            <div className="wrapper">
                <div className="inner-warpper text-center">
                    <h2 className="title">Login to your account</h2>
                    <form ref={formRef} id="formvalidate">
                        <div className="input-group">
                            <input
                                className="form-control border-dark"
                                id="userName"
                                type="text"
                                placeholder="Enter University/Placement Id"
                                onChange={(e) => setId(e.target.value)}
                                required />

                            {/* <span className="lighting"></span> */}
                        </div>
                        <div className="input-group">
                            <input
                                className="form-control border-dark"
                                id="userPassword"
                                type="password"
                                placeholder="Enter password"
                                onChange={(e) => setPassword(e.target.value)}
                                required />
                            {/* <span className="lighting"></span> */}
                        </div>

                        <button type="submit" id="login" onClick={(e) => handleSubmit(e)}>
                            Login
                        </button>
                    </form>
                </div>
                <div className="signup-wrapper text-center">
                    <button type="button" onClick={(e) => NavigateToSignup(e)}>
                        Don't have an account? <span className="text-primary">Create One</span>
                    </button>
                    
                </div>
            </div>
            {
                alertBool &&
                <>
                    <ClimbingBoxLoader loading={loading} color="#00a885" style={{ margin:"auto" }} />
                    <div className="alert alert-danger alert-box" role="alert">
                        Wrong username or Password. Please try again
                    </div></>
            }
        </>
    );
}

export default AuthorizationForm;



