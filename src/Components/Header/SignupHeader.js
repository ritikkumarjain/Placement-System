import { useNavigate } from "react-router-dom";
import "./LoginHeader.css"

function SignupHeader() {

    const navigate = useNavigate();
    function GoBack() {
        navigate("/");
        return;
    }

    return (
        <>

            <div className="signupPage-title">
                <div>
                    <h3 className="signup-title-tags">Placement Portal</h3>
                </div>
                <div>
                    <button type="button" className="btn btn-primary" onClick={()=>GoBack()}>Go Back</button>
                </div>
            </div>
        </>
    );
}

export default SignupHeader;