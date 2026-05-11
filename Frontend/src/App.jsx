import { useEffect, useState } from 'react'
import './App.css'

function App() {
  const [candidateName, setCandidateName] = useState('');
  const [candidateBirth, setCandidateBirth] = useState('');
  const [candidatePhone, setCandidatePhone] = useState('');
  const [candidateEmail, setCandidateEmail] = useState('');

  const [skillName, setSkillName] = useState("");

  const [allCandidates, setAllCandidates] = useState([]);
  const [allSkills, setAllSkills] = useState([]);

  const url = 'http://localhost:5290/api'

  const handleCandidateSubmit = (e) => {
    e.preventDefault();

    const candidate = {
      name: candidateName, birthDate: candidateBirth, phoneNumber: candidatePhone, email: candidateEmail
    };
    fetch('http://localhost:5290/api/candidate', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(candidate)
    }).then(res => res.json())
  }

  const handleSkillSubmit = (e) => {
    e.preventDefault();

    const skill = {
      name: skillName
    };
    fetch('http://localhost:5290/api/skill', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(skill)
    }).then(res => res.json())
  }

  return (
    <div>
      <h1>HR Platform</h1>

      <div className="forms-container">
        <div className='card'>
          <h2>New candidate</h2>
          <form onSubmit={handleCandidateSubmit} className='form-column'>
            <input className='input' placeholder='Full name' value={candidateName} onChange={e => setCandidateName(e.target.value)}></input>
            <input className='input' type='date' value={candidateBirth} onChange={e => setCandidateBirth(e.target.value)}></input>
            <input className='input' placeholder='Phone number' value={candidatePhone} onChange={e => setCandidatePhone(e.target.value)}></input>
            <input className='input' placeholder='Email' value={candidateEmail} onChange={e => setCandidateEmail(e.target.value)}></input>
            <button className='button' type='submit'>Create</button>
          </form>
        </div>
              <div className='card'>
          <h2>New skill</h2>
          <form onSubmit={handleSkillSubmit}>
            <input className='input' placeholder='Skill name' value={skillName} onChange={e => setSkillName(e.target.value)}></input>
            <button className='button' type='submit'>Create</button>
          </form>
        </div>
      </div>
    </div>
  )
}

export default App
