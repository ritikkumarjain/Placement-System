import Header from "../../Header/CoordinatorHeader";
import Footer from "../../Footer/Footer";
import "./CoordinatorView.css";
import React, { useState, useRef } from 'react';
import { useNavigate } from "react-router-dom";
import ClimbingBoxLoader from "react-spinners/ClimbingBoxLoader";


function UpdatePlacement() {
    const [universityId, setUniversityId] = useState("");
    const [registrationNumber, setRegistrationNumber] = useState("");
    const [placementCompanyI, setPlacementCompanyI] = useState("");
    const [placementCompanyII, setPlacementCompanyII] = useState("");
    const [placementTypeI, setPlacementTypeI] = useState("");
    const [placementTypeII, setPlacementTypeII] = useState("");
    const formRef = useRef(null);
    const navigate = useNavigate();
    const [alertBool, setAlertBool] = useState(false);
    const [viewAlert, setViewAlert] = useState(true);
    const [loading, setLoading] = useState(false);


    async function HandleSubmitToViewData(e) {
        e.preventDefault();
        setLoading(true);

        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            setLoading(false);
            return;
        }

        await fetch(`https://localhost:44346/api/StudentsPlacementCoordinators/ViewSingleStudentDetails/${universityId}/${registrationNumber}`)
            .then(response => response.json())
            .then(data => {
                if (data.status === 404) {
                    alert("Something went wrong");
                    return;
                }
                if (data) {
                    setUniversityId(data.universityId);
                    setRegistrationNumber(data.registrationNumber);
                    setPlacementTypeI(data.placementTypeI);
                    setPlacementTypeII(data.placementTypeII);
                    setPlacementCompanyI(data.placementCompanyI);
                    setPlacementCompanyII(data.placementCompanyII);
                    setViewAlert(false);
                    setLoading(false);

                    return;
                }
                setLoading(false);

                setViewAlert(true);
            })
            .catch(error => {
                alert("Error Occured.Please Check inputs");
                setLoading(false);

                window.location.reload();

            });
    };


    async function HandleSubmit(e) {
        e.preventDefault();
        setAlertBool(true);
        setLoading(true);


        if (!formRef.current?.reportValidity()) {
            alert("Wrong or Unfilled Inputs");
            setLoading(false);
            setAlertBool(false);
            return;
        }

        const postData = {
            universityId,
            registrationNumber,
            placementTypeI,
            placementCompanyI: placementCompanyI.toUpperCase(),
            placementTypeII,
            placementCompanyII: placementCompanyII.toUpperCase()
        }

        await fetch("https://localhost:44346/api/StudentsPlacementCoordinators/EditStudentsPlacementsDetails", {
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
                console.log(data);
                if (data) {
                    setLoading(false);

                    return;
                }
                setLoading(false);

                setAlertBool(false);
            })
            .catch(error => {
                setLoading(false);
                alert("Please Create Placement Data First");
                window.location.reload();
            });
    };






    const OnCancel = () => {
        navigate("/coordinators-menu/");
    }

    const NotCancel = (e) => {
        e.preventDefault();
    }

    return (
        <>
            <Header />
            {
                viewAlert ?


                    //  Fetch Form 
                    (
                        <div className="coordinator-create-container">
                            <form ref={formRef}>
                                <div className="form-group">
                                    <h2 className="heading">Enter Details..</h2>

                                    <div className="d-flex row">
                                        <div className="form-group col-md-6">
                                            <label htmlFor="inputUniverityId" className="col-form-label">UniversityId</label>
                                            <input type="text" className="form-control" id="inputUniversityId" placeholder="Enter University Id" onChange={(e) => setUniversityId(e.target.value)} pattern="^[1-9][0-9]{11}$" required />
                                        </div>
                                        <div className="form-group col-md-6">
                                            <label htmlFor="inputRegistrationNumber" className="col-form-label">Registration No.</label>
                                            <input type="text" className="form-control" id="inputRegistrationNumber" placeholder="Enter Registration Number" onChange={(e) => setRegistrationNumber(e.target.value)} pattern="^[1-9][0-9]{8}$" required />
                                        </div>
                                    </div>
                                </div>
                            </form>
                            <div className="d-flex submit-reset-buttons justify-content-center">
                                <button type="submit" className="btn btn-success" onClick={(e) => HandleSubmitToViewData(e)}>Fetch</button>
                                <button type="reset" className="btn btn-danger" onClick={(e) => window.location.reload()}>Reset</button>
                            </div>
                        </div>


                    )

                    :

                    //    Update Form 
                    (
                        <>
                            <div className="coordinator-create-container">
                                <ClimbingBoxLoader loading={loading} color="#00a885" style={{ margin: "auto" }} /><div className="coordinator-create-container">
                                    <form ref={formRef}>
                                        <div className="form-group">
                                            <h2 className="heading">Enter Details..</h2>

                                            <div className="d-flex row">
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputUniverityId" className="col-form-label">University Id</label>
                                                    <input type="text" className="form-control" id="inputUniversityId" placeholder="Enter University Id" onChange={(e) => setUniversityId(e.target.value)} value={universityId} disabled />
                                                </div>
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputRegistrationNumber" className="col-form-label">Registration No.</label>
                                                    <input type="text" className="form-control" id="inputRegistrationNumber" placeholder="Enter Registration Number" onChange={(e) => setRegistrationNumber(e.target.value)} value={registrationNumber} disabled />
                                                </div>
                                            </div>

                                            <div className="d-flex row">
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputPlacementTypeI" className="col-form-label">Placement Type I</label>
                                                    <select id="inputPlacementTypeI" className="form-control" onChange={(e) => setPlacementTypeI(e.target.value)} value={placementTypeI} required>
                                                        <option selected disabled>Choose Type...</option>
                                                        <option value="Tier I">Tier I</option>
                                                        <option value="Tier II">Tier II</option>
                                                        <option value="Tier III">Tier III</option>
                                                        <option value="NA">NA</option>
                                                    </select>
                                                </div>
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputPlacementTypeII" className="col-form-label">Placement Type II</label>
                                                    <select id="inputPlacementTypeII" className="form-control" onChange={(e) => setPlacementTypeII(e.target.value)} value={placementTypeII} required>
                                                        <option selected disabled>Choose Type...</option>
                                                        <option value="Tier I">Tier I</option>
                                                        <option value="Tier II">Tier II</option>
                                                        <option value="Tier III">Tier III</option>
                                                        <option value="NA">NA</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div className="d-flex row">
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputPlacementCompanyI" className="col-form-label">Placement Company I</label>
                                                    <input type="text" className="form-control" id="inputPlacementCompanyI" placeholder="Enter Placement Company I" onChange={(e) => setPlacementCompanyI(e.target.value)} value={placementCompanyI} maxlength="30" minLenth="3" pattern="^[a-zA-Z]{4,}(?: [a-zA-Z]+){0,2}$|^NA$|^Na$|^nA$|^na$" required />
                                                </div>
                                                <div className="form-group col-md-6">
                                                    <label htmlFor="inputPlacementCompanyII" className="col-form-label">Placement Company II</label>
                                                    <input type="text" className="form-control" id="inputPlacementCompanyII" placeholder="Enter Placement Company II" onChange={(e) => setPlacementCompanyII(e.target.value)} value={placementCompanyII} maxlength="30" minLenth="3" pattern="^[a-zA-Z]{4,}(?: [a-zA-Z]+){0,2}$|^NA$|^Na$|^nA$|^na$" required />
                                                </div>
                                            </div>

                                            <div className="d-flex submit-reset-buttons justify-content-center">
                                                <button type="submit" className="btn btn-success" onClick={(e) => HandleSubmit(e)}>Submit</button>
                                                <button type="reset" className="btn btn-danger" onClick={(e) => window.location.reload()}>Reset</button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                {/* Status Alert  */}
                                {
                                    alertBool &&
                                    <>
                                        <ClimbingBoxLoader loading={loading} color="#00a885" style={{ margin: "auto" }} />
                                        <div className="alert alert-info alert-box" role="alert">
                                            Data Successfully Updated
                                        </div></>
                                }
                            </div>

                        </>
                    )
            }



            

            <Footer />
        </>
    );
}

export default UpdatePlacement;