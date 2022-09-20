import "./Header.css";
import {useNavigate} from "react-router-dom";
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import ButtonGroup from '@mui/material/ButtonGroup';
import Stack from '@mui/material/Stack';

function Header() {
    const navigate = useNavigate();


    function handleLogout(e){
        e.preventDefault();
        localStorage.removeItem("user-info");
        navigate("/");
        return;
    }

    function GoBack(){
        navigate("/coordinators-menu/");
        return;
    }

    return (
        <>
            <div className="header-container">
                <div className="">
                    <h3 className="">Placement Portal</h3>
                </div>
                <div>
                    <Stack direction="row" spacing={2} className="stack">
                        <Button variant="contained" style={{ backgroundColor: "#64dd17" }} onClick={(e) => GoBack(e)} className="header-buttons">Back</Button>
                        <Button style={{ backgroundColor: "#482880" }} variant="contained" onClick={(e) => handleLogout(e)} className="header-buttons">LogOut</Button>
                    </Stack>
                </div>
            </div>
        </>
    );
}

export default Header;