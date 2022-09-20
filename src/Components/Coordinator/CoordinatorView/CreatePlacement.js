import Header from "../../Header/CoordinatorHeader";
import Footer from "../../Footer/Footer";
import "./CoordinatorView.css";
import { useNavigate } from "react-router-dom";
import React, { useState, useRef } from 'react';
import ClimbingBoxLoader from "react-spinners/ClimbingBoxLoader";


function CreateStudent() {
    const [universityId, setUniversityId] = useState("");
    const [registrationNumber, setRegistrationNumber] = useState("");

    const formRef = useRef(null);

    const navigate = useNavigate();
    const [alertBool, setAlertBool] = useState(false);
    const [loading, setLoading] = useState(false);



    async function HandleSubmit(e) {
        e.preventDefault();
        setLoading(true);



        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            setLoading(false);
            return;
        }

        const postData = {
            universityId,
            registrationNumber
        }

        await fetch("https://localhost:44346/api/StudentsPlacementCoordinators/CreateStudentsPlacementsDetails", {
            method: "POST",
            headers: new Headers({
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify(postData)
        })
            .then(response => response.json())
            .then(data => {
                if (data.status === 404 || data === false) {
                    alert("Something went wrong");
                    setLoading(false);
                    return;
                }
                if (data) {
                    console.log(data);
                    setLoading(false);
                    setAlertBool(true);
                    return;
                }
                setLoading(false);
                setAlertBool(false);
            })
            .catch(error => {
                alert("Error Occured.Data is already in the database");
                setLoading(false);
                window.location.reload();
            });
    };




    return (
        <>
            <Header />
            <div className="coordinator-create-container">
                <form ref={formRef}>
                    <div className="form-group">
                        <h2 className="heading">Enter Details..</h2>
                        <div className="d-flex row">
                            <div className="form-group col-md-6">
                                <label htmlFor="inputUniverityId" className="col-form-label">University Id</label>
                                <input type="text" className="form-control" id="inputUniversityId" placeholder="Enter University Id" onChange={(e) => setUniversityId(e.target.value)} pattern="^[1-9][0-9]{11}$" required/>
                            </div>
                            <div className="form-group col-md-6">
                                <label htmlFor="inputRegistrationNumber" className="col-form-label">Registration No.</label>
                                <input type="text" className="form-control" id="inputRegistrationNumber" placeholder="Enter Registration Number" onChange={(e) => setRegistrationNumber(e.target.value)} pattern="^[1-9][0-9]{8}$" required />
                            </div>
                        </div>

                        <div className="d-flex submit-reset-buttons justify-content-center">
                            <button type="submit" className="btn btn-success" onClick={(e) => HandleSubmit(e)}>Submit</button>
                            <button type="reset" className="btn btn-danger" onClick={(e) => window.location.reload()}>Reset</button>
                        </div>
                    </div>
                </form>
                <ClimbingBoxLoader loading={loading} color="#00a885" style={{ margin: "auto" }} />
                {
                    alertBool &&

                    <>
                        <div class="alert alert-info alert-box" role="alert">
                            Data Successfully Created
                        </div></>
                }
            </div>
            

            <Footer />

        </>
    );
}

export default CreateStudent;