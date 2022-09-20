import './App.css';
import Student from './Components/Student/Student';
import CreateStudent from './Components/Student/StudentView/CreateStudent';
import UpdateStudent from './Components/Student/StudentView/UpdateStudent';
import ViewStudent from './Components/Student/StudentView/ViewStudent';
import Coordinator from './Components/Coordinator/Coordinator';
import CreatePlacement from './Components/Coordinator/CoordinatorView/CreatePlacement';
import UpdatePlacement from './Components/Coordinator/CoordinatorView/UpdatePlacement';
import ViewPlacement from './Components/Coordinator/CoordinatorView/ViewPlacement';
import Authorization from './Components/Authorization/AuthorizationPage';
import Signup from './Components/Authorization/Signup';

import { Routes, Route } from 'react-router-dom';

function App() {
    return (
        <>
            <Routes>
                <Route path="/students-menu/" element={<Student />} />
                <Route path="/students-menu/create/" element={<CreateStudent />} />
                <Route path="/students-menu/update/" element={<UpdateStudent />} />
                <Route path="/students-menu/view/" element={<ViewStudent />} />
                <Route path="/coordinators-menu/" element={<Coordinator />} />
                <Route path="/coordinators-menu/create/" element={<CreatePlacement />} />
                <Route path="/coordinators-menu/update/" element={<UpdatePlacement />} />
                <Route path="/coordinators-menu/view/" element={<ViewPlacement />} />
                <Route path="/" element={<Authorization />} />
                <Route path="/signup/" element={<Signup />} />

            </Routes>
        </>
    );
}

export default App;
