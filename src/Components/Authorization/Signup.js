import React, { useState, useRef } from "react";
import { useNavigate } from 'react-router-dom';
import Footer from "../Footer/Footer";
import SignupHeader from "../Header/SignupHeader";
import "./AuthorizationForm.css";



function SignUp() {

    const [universityId, setId] = useState("");
    const [password, setPassword] = useState("");
    const [role, setRole] = useState("");
    const [alertBool, setAlertBool] = useState(false);
    const formRef = useRef(null);


    async function SignUp(e) {
        e.preventDefault();
        // if (!formRef.current?.reportValidity()) {
        //     alert("Wrong or Unfilled Inputs");
        //     return;
        // }

        if (universityId.length !== 9 && universityId.length !== 12) {
            // console.log(universityId.length);
            alert("Please enter Correct University Id");
            return;
        }

        if (universityId.length === 12 && role !== "Student") {
            alert("Please Select the correct role with respect to Id");
            return;
        }

        if (universityId.length === 9 && role !== "Coordinator") {
            alert("Please Select the correct role with respect to Id");
            return;
        }


        let postData = { universityId, password, role };
        await fetch("https://localhost:44330/api/Authorization/NewUser", {
            method: "POST",
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify(postData)
        })
            .then(response => response.json())
            .then(() => {
                setAlertBool(true);
            })
            .catch(error => {
                alert("Something went wrong: " + error.message);
                window.location.reload();
            })
    }



    return (
        <>
            <SignupHeader />
            <div className="logo text-center">
                <h1 className="lead display-3">Placement System</h1>
            </div>
            <div className="wrapper">
                <div className="inner-warpper text-center">
                    <h2 className="title">Sign Up</h2>
                    <form ref={formRef}>
                        <div className="input-group">
                            <input
                                className="form-control border-dark"
                                id="userName"
                                type="text"
                                placeholder="Enter Id. Must be 12 or 9 digits"
                                onChange={(e) => setId(e.target.value)}
                                pattern="^[1-9][0-9]{11}$|^[1-9][0-9]{8}$"
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

                        <div className="input-group">
                            {/* <label htmlFor="inputRole" className="col-form-label">Role</label> */}
                            <select id="inputRole" className="form-control border-dark" onChange={(e) => setRole(e.target.value)} required>
                                <option selected disabled>Choose Role...</option>
                                <option value="Student">Student</option>
                                <option value="Coordinator">Coordinator</option>
                            </select>
                        </div>
                        <button type="submit" id="login" onClick={(e) => SignUp(e)}>
                            Sign Up
                        </button>
                    </form>
                </div>

            </div>
            {
                alertBool &&
                <div className="alert alert-info alert-box" role="alert">
                    Successfully Signed Up. You may exit this page
                </div>
            }
            <Footer />
        </>
    );
}

export default SignUp;